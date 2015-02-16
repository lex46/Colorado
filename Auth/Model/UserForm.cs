using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Auth.Infra;

namespace Auth.Model
{
    public class UserForm : BaseModel
    {
        public string Name { get; set; }
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [Column]
        private string Values { get; set; }
        [NotMapped]
        public string[] FormValues
        {
            get
            {
                return Values.Split(new[] { Constants.DbArraySeparator }, StringSplitOptions.None);
            }

            set
            {
                Values = String.Join(Constants.DbArraySeparator, value);
            }
        }
        public UserForm()
        {
            FormValues = new string[0];
        }
    }
}