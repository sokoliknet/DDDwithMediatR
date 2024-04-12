using System.ComponentModel.DataAnnotations;

namespace DDDwithMediatR.Domain_Layer.Models
{
    public class BusinessEntity
    {
        [Key]
        public int BusinessEntityID { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual Person Person { get; set; }
    }
}
