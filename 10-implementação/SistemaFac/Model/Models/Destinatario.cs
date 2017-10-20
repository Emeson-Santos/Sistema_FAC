
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Models
{
    public class Destinatario
    {

        private int id;
        private string email;

        public Destinatario(string email, int id)
        {
            this.email = email;
            this.id = id;

        }
        
        public int Id
        {
            get { return id; }
            set { id = value; }

        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


    }
}
