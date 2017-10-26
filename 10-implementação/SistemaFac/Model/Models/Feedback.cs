
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Model.Models
{
    public class Feedback
    {
        private int id;
        private string texfeedback;

        public Feedback(int id, string texfeedback)
        {
            this.id = id;
            this.texfeedback = texfeedback;
        }
        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [Required(ErrorMessage = "Por favor, faça seu Feedback!")]
        [Display(Name = "Fedback:")]
        public string TextFeedback
        {
            get { return TextFeedback; }
            set { TextFeedback = value; }
        }




    }
}
