namespace DDDwithMediatR.Application_Layer.Dto
{
    public class PersonDto
    {
        public int BusinessEntityID { get; set; }
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int EmailPromotion { get; set; }
        public Guid? rowguid { get; set; } = null!;
        public DateTime ModifiedDate { get; set; }
    }
}
