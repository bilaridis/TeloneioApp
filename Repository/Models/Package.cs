namespace DomainModel.Models
{
    public class Package
    {
        public int Id { get; set; }

        public string PackageId { get; set; }

        public string PackageDescr { get; set; }

        public string PackageDispalyDescr => $"{PackageId} - {PackageDescr}";
    }
}