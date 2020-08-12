using Dapper;
using MVC_API_DAPPER.Common;
using MVC_API_DAPPER.IServices;
using MVC_API_DAPPER.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MVC_API_DAPPER.Services
{
    public class PersonService : IPersonService
    {
        Person _oPerson = new Person();
        List<Person> _oPersons = new List<Person>();
        public string Delete(int personId)
        {
            string message = "";
            try
            {
                _oPerson = new Person()
                {
                    PersonId = personId
                };

                using (IDbConnection cnn = new OracleConnection(Global.ConnectionOracle))
                {
                    if (cnn.State == ConnectionState.Closed) cnn.Open();

                    var oPersons = cnn.Query<Person>("SP_Person",
                        this.SetParameters(_oPerson,(int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure
                        );
                    if (oPersons != null && oPersons.Count() > 0)
                    {
                        _oPerson = oPersons.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }

        public Person Get(int personId)
        {
            _oPerson = new Person();
            using (IDbConnection cnn = new OracleConnection(Global.ConnectionOracle))
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();

                var oPersons = cnn.Query<Person>("SELECT * FROM Person WHERE PersonId = " + personId).ToList();

                if (oPersons != null && oPersons.Count() > 0)
                {
                    //SingleOrDefault()
                    _oPerson = oPersons.SingleOrDefault();
                }
            }
            return _oPerson;
        }

        public List<Person> Gets()
        {
            _oPersons = new List<Person>();
            using (IDbConnection cnn = new OracleConnection(Global.ConnectionOracle))
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();

                var oPersons = cnn.Query<Person>("SELECT * FROM Person").ToList();

                if (oPersons != null && oPersons.Count() > 0)
                {
                    _oPersons = oPersons;
                }
            }
            return _oPersons;
        }

        public Person Save(Person oPerson)
        {
            _oPerson = new Person();
            try
            {
                int operationType = Convert.ToInt32(oPerson.PersonId == 0 ? OperationType.Insert : OperationType.Update);
                using (IDbConnection cnn = new OracleConnection(Global.ConnectionOracle))
                {
                    if (cnn.State == ConnectionState.Closed) cnn.Open();

                    var oPersons = cnn.Query<Person>(
                        "SP_Person",
                        this.SetParameters(oPerson, operationType),
                        commandType: CommandType.StoredProcedure
                        );
                    if (oPersons != null && oPersons.Count() > 0)
                    {
                        _oPerson = oPersons.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oPerson.Message = ex.Message;
            }
            return _oPerson;
        }

        private DynamicParameters SetParameters(Person oPerson, int operationType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PersonId", oPerson.PersonId);
            parameters.Add("@Name", oPerson.Name);
            parameters.Add("@Roll", oPerson.Roll);
            parameters.Add("@OperationType", operationType);
            return parameters;
        }
    }
}
