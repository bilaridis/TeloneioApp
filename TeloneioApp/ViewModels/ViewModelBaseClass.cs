using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace TeloneioApp.ViewModels
{
    public class ViewModelBaseClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        [TypeDescriptionProvider(typeof(CommandMapDescriptionProvider))]
        public class CommandMap
        {
            private Dictionary<string, ICommand> _commands;

            protected Dictionary<string, ICommand> Commands
            {
                get
                {
                    if (null == _commands) _commands = new Dictionary<string, ICommand>();
                    return _commands;
                }
            }

            public void AddCommand(string commandName, Action<object> executeMethod)
            {
                Commands[commandName] = new DelegateCommand(executeMethod);
            }

            public void AddCommand(string commandName, Action<object> executeMethod, Predicate<object> canExecuteMethod)
            {
                Commands[commandName] = new DelegateCommand(executeMethod, canExecuteMethod);
            }

            public void RemoveCommand(string commandName)
            {
                Commands.Remove(commandName);
            }

            private class DelegateCommand : ICommand
            {
                private readonly Predicate<object> _canExecuteMethod;
                private readonly Action<object> _executeMethod;

                public DelegateCommand(Action<object> executeMethod) : this(executeMethod, null)
                {
                }

                public DelegateCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod)
                {
                    if (null == executeMethod) throw new ArgumentNullException("executeMethod");
                    _executeMethod = executeMethod;
                    _canExecuteMethod = canExecuteMethod;
                }

                public bool CanExecute(object parameter)
                {
                    return null == _canExecuteMethod ? true : _canExecuteMethod(parameter);
                }

                public event EventHandler CanExecuteChanged
                {
                    add => CommandManager.RequerySuggested += value;
                    remove => CommandManager.RequerySuggested -= value;
                }

                public void Execute(object parameter)
                {
                    _executeMethod(parameter);
                }
            }

            private class CommandMapDescriptionProvider : TypeDescriptionProvider
            {
                public CommandMapDescriptionProvider() : this(TypeDescriptor.GetProvider(typeof(CommandMap)))
                {
                }

                public CommandMapDescriptionProvider(TypeDescriptionProvider parent) : base(parent)
                {
                }

                public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
                {
                    return new CommandMapDescriptor(base.GetTypeDescriptor(objectType, instance),
                        instance as CommandMap);
                }
            }

            private class CommandMapDescriptor : CustomTypeDescriptor
            {
                private readonly CommandMap _map;

                public CommandMapDescriptor(ICustomTypeDescriptor descriptor, CommandMap map) : base(descriptor)
                {
                    _map = map;
                }

                public override PropertyDescriptorCollection GetProperties()
                {
                    var props = new PropertyDescriptor[_map.Commands.Count];
                    var pos = 0;
                    foreach (var command in _map.Commands)
                        props[pos++] = new CommandPropertyDescriptor(command);
                    return new PropertyDescriptorCollection(props);
                }
            }

            private class CommandPropertyDescriptor : PropertyDescriptor
            {
                private ICommand _command;

                public CommandPropertyDescriptor(KeyValuePair<string, ICommand> command) : base(command.Key, null)
                {
                    _command = command.Value;
                }

                public override bool IsReadOnly => true;
                public override Type ComponentType => throw new NotImplementedException();
                public override Type PropertyType => typeof(ICommand);

                public override bool CanResetValue(object component)
                {
                    return false;
                }

                public override object GetValue(object component)
                {
                    var map = component as CommandMap;
                    if (null == map) throw new ArgumentException("component is not a CommandMap instance", "component");
                    return map.Commands[Name];
                }

                public override void ResetValue(object component)
                {
                    throw new NotImplementedException();
                }

                public override void SetValue(object component, object value)
                {
                    throw new NotImplementedException();
                }

                public override bool ShouldSerializeValue(object component)
                {
                    return false;
                }
            }
        }
    }
}