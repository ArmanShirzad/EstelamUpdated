namespace EstelamIsargari.Pages
{
    public class ResponseModel
    {
        public string ErrorMessage { get; set; }
        public long ApplicantId { get; set; }
        public PersonBrDTO Isargar { get; set; }
        public bool IsShd { get; set; }
        public bool IsJbz { get; set; }
        public bool IsAzd { get; set; }
        public bool IsMfq { get; set; }
        public bool IsAsr { get; set; }
        public DateTime? ShdDate { get; set; } = null;
        public int? JbzPercent { get; set; } = null;
        public int? CaptivityDuration { get; set; } = null;
        public List<PersonBrDTO> Childs { get; set; } = new List<PersonBrDTO>();
        public List<PersonBrDTO> Parents { get; set; } = new List<PersonBrDTO>();
        public bool IsError { get; set; }
        public string ErrorCode { get; set; }
        public int StatusCode { get; set; }

    }
    public class PersonBrDTO
    {
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public bool? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? IsLiving { get; set; }
        public DateTime? DeathDate { get; set; }
        public string IdCardNumber { get; set; }
        public int? Stateld { get; set; }
        public string StateTitle { get; set; }
        public int? RelationshipTypeId { get; set; }
        public bool IsRelationshipNatural { get; set; }
    }
}
