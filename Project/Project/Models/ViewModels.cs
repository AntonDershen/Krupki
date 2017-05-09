using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Web.Mvc;
using Resources;

namespace Project.Models
{
    public class NewsView
    {
        [Required]
        [Display(ResourceType = typeof(I18n), Name = "Field_Header")]
        public string Header { get; set; }

        [Required]
        [Display(ResourceType = typeof(I18n), Name = "Field_Body")]
        public string Body { get; set; }
    }
    public class ReceptionsView
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessageResourceType = typeof (I18n),
            ErrorMessageResourceName = "IncorrectEmail")]
        [Display(ResourceType = typeof (I18n), Name = "AdressEmail")]
        public string EMail { get; set; }

        [Required]
        [Display(ResourceType = typeof (I18n), Name = "Index")]
        public string Index { get; set; }

        [Required]
        [Display(ResourceType = typeof (I18n), Name = "Adress")]
        public string Adress { get; set; }

        [Required]
        [Display(ResourceType = typeof (I18n), Name = "InformationReceptionYL")]
        public string Information { get; set; }

        [Required]
        [Display(ResourceType = typeof (I18n), Name = "TextReception")]
        public string Body { get; set; }

        [Required]
        public string Type { get; set; }
    }
    public class RequestView
    {
        [Required]
        public int ReceptionId { get; set; }
        [Required]
        [Display(ResourceType = typeof(I18n), Name = "TextReception")]
        public string Body { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessageResourceType = typeof (I18n),
            ErrorMessageResourceName = "IncorrectEmail")]
        [Display(ResourceType = typeof (I18n), Name = "AdressEmail")]
        public string RequestEMail { get; set; }
        
        [Required]
        [Display(ResourceType = typeof(I18n), Name = "Field_Password")]
        public string Password { get; set; }
    }
    public class DocumentsView
    {
        [Required]
        [Display(ResourceType = typeof(I18n), Name = "Field_Description")]
        public string Description { get; set; }

        [Required]
        [Display(ResourceType = typeof(I18n), Name = "Field_Type")]
        public string Type { get; set; }
    }
    public class LeaderView
    {
        [Required]
        [Display(ResourceType = typeof(I18n), Name = "Field_FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(ResourceType = typeof(I18n), Name = "Field_LastName")]
        public string LastName { get; set; }
        [Required]
        [Display(ResourceType = typeof(I18n), Name = "Field_MiddleName")]
        public string MiddleName { get; set; }
        [Required]
        [Display(ResourceType = typeof(I18n), Name = "Field_Description")]
        public string Description { get; set; }
        [Required]
        [Display(ResourceType = typeof(I18n), Name = "Field_Position")]
        public string Position { get; set; }
    }
    public class JobsView
    {
        [Required]
        [Display(ResourceType = typeof(I18n), Name = "Profession")]
        public string Header { get; set; }

        [Required]
        public string Body { get; set; }
    }
}