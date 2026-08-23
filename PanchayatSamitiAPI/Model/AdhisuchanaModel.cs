using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanchayatSamitiAPI.Model
{
    public class AdhisuchanaModel
    {
        public int Id { get; set; }

       public bool IsActive { get; set; }

        public Guid UniqueId { get; set; }

       
        public string EmployeeName { get; set; }

  
        public string Type { get; set; } 


        public string TypeName { get; set; } 

   
        public string Designation { get; set; } 

        public DateOnly DateOfBirth { get; set; }

   
        public string Class { get; set; } 

        public DateOnly CompletionOfAgeofRetirement5860 { get; set; }

        public DateOnly RetirementDate { get; set; }

        public int SandarbhNumber { get; set; }

        public DateOnly SandarbhDate { get; set; }


        public string? CreatedBy { get; set; }

     
        public string? UpdatedBy { get; set; }

      
        public DateTime CreatedDate { get; set; }

      
        public DateTime ModifiedDate { get; set; }

  

        public string LoginUser { get; set; } 

 
        public DateTime EntryDate { get; set; }

        public string Status { get; set; } 

        public string FinancialYear { get; set; } 

    }
}
