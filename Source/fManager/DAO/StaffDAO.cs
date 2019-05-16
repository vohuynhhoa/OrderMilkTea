using fManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fManager.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get
            {
                if (instance == null) instance = new StaffDAO(); return StaffDAO.instance;
            }

            private set
            {
                StaffDAO.instance = value;
            }
        }
        private StaffDAO() { }
        public List<Staff> GetListStaff()
        {
            List<Staff> list = new List<Staff>();

            string query = "select * from Staff";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                list.Add(staff);
            }

            return list;
        }
        public List<Staff> SearchStaffByName(string name)
        {

            List<Staff> list = new List<Staff>();

            string query = string.Format("SELECT * FROM dbo.Staff WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                list.Add(staff);
            }

            return list;
        }
        public bool InsertStaff(string name, string sex, int numberphone, string address)
        {
            string query = string.Format("INSERT dbo.Staff ( name, sex, numberphone, address )VALUES  ( N'{0}', N'{1}', {2}, N'{3}')", name, sex, numberphone, address);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateStaff(int idStaff, string name, string sex, int numberphone, string address)
        {
            string query = string.Format("UPDATE dbo.Staff SET name = N'{0}', sex = N'{1}', numberphone = {2}, address=N'{3}' WHERE id = {4}", name, sex, numberphone, address, idStaff);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteStaff(int id)
        {
            

            string query = string.Format("Delete Staff where id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
