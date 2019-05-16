using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fManager.DTO
{
    public class Staff
    {
        public Staff(int id, string name,string sex, int numberphone, string address)
        {
            this.ID = id;
            this.Name = name;
            this.Sex = sex;
            this.NumberPhone = numberphone;
            this.Address = address;
        }

        public Staff(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Sex = row["sex"].ToString();
            this.NumberPhone = (int)row["numberphone"];
            this.Address= row["address"].ToString();
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }

        }
        private int numberPhone;

        public int NumberPhone
        {
            get { return numberPhone; }
            set { numberPhone = value; }

        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }

        }
        private string sex;

        public string Sex
        {
            get { return sex; }
            set { sex = value; }

        }


    }
}
