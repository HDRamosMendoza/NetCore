using Dapper;
using MVC_API_DAPPER.Common;
using MVC_API_DAPPER.IServices;
using MVC_API_DAPPER.Models;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_API_DAPPER.Services
{
    public class PositionService : IPositionService
    {
        Position _oPosition = new Position();
        List<Position> _oPositions = new List<Position>();
        public string Delete(int positionId)
        {
            /* Falta probar. No se a creado la función del lado de base de datos */
            string message = "";
            try
            {
                _oPosition = new Position()
                {
                    PositionId = positionId
                };

                using (IDbConnection cnn = new NpgsqlConnection(Global.ConnectionPostgres))
                {
                    if (cnn.State == ConnectionState.Closed) cnn.Open();

                    var oPositions = cnn.Query<Position>("SP_Position",
                        this.SetParameters(_oPosition, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure
                        );
                    if (oPositions != null && oPositions.Count() > 0)
                    {
                        _oPosition = oPositions.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }

        public Position Get(int positionId)
        {
            _oPosition = new Position();
            using (IDbConnection cnn = new NpgsqlConnection(Global.ConnectionPostgres))
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();

                var oPositions = cnn.Query<Position>("SELECT * FROM \"Position\" WHERE \"PositionId\" = " + positionId).ToList();

                if (oPositions != null && oPositions.Count() > 0)
                {
                    //SingleOrDefault()
                    _oPosition = oPositions.SingleOrDefault();
                }
            }
            return _oPosition;
        }

        public List<Position> Gets()
        {
            _oPositions = new List<Position>();
            using (IDbConnection cnn = new NpgsqlConnection(Global.ConnectionPostgres))
            {
                if (cnn.State == ConnectionState.Closed) cnn.Open();

                var oPositions = cnn.Query<Position>("SELECT * FROM \"Person\"").ToList();

                if (oPositions != null && oPositions.Count() > 0)
                {
                    _oPositions = oPositions;
                }
            }
            return _oPositions;
        }

        public Position Save(Position oPosition)
        {
            /* Falta probar. No se a creado la función del lado de base de datos */
            _oPosition = new Position();
            try
            {
                int operationType = Convert.ToInt32(oPosition.PositionId == 0 ? OperationType.Insert : OperationType.Update);
                using (IDbConnection cnn = new NpgsqlConnection(Global.ConnectionPostgres))
                {
                    if (cnn.State == ConnectionState.Closed) cnn.Open();

                    var oPositions = cnn.Query<Position>(
                        "SP_Position",
                        this.SetParameters(oPosition, operationType),
                        commandType: CommandType.StoredProcedure
                        );
                    if (oPositions != null && oPositions.Count() > 0)
                    {
                        _oPosition = oPositions.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oPosition.Message = ex.Message;
            }
            return _oPosition;
        }

        private DynamicParameters SetParameters(Position oPosition, int operationType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PositionId", oPosition.PositionId);
            parameters.Add("@Name", oPosition.Name);
            parameters.Add("@Roll", oPosition.Roll);
            parameters.Add("@OperationType", operationType);
            return parameters;
        }
    }
}
