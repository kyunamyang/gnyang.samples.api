using gnyang.samples.domain.Entities;
using gnyang.samples.infrastructure.Interfaces;
using gnyang.samples.infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Runtime;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace gnyang.samples.infrastructure
{

    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;

        private DbSettings _dbSettings;
        private IDbConnection? _connection;
        private IDbTransaction? _transaction;

        public IProductRepository ProductRepository { get; init; }

        public UnitOfWork(IOptions<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
            _connection = new SqlConnection(
                $"Server={_dbSettings.Server}; Database={_dbSettings.Database}; User Id={_dbSettings.UserId}; Password={_dbSettings.Password}; TrustServerCertificate=true;"
            );
            _connection.Open();

            _transaction = _connection.BeginTransaction(IsolationLevel.ReadCommitted);

            ProductRepository = new ProductRepository(_transaction);
        }

        public void Commit()
            => _transaction?.Commit();

        public void Rollback()
            => _transaction?.Rollback();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                    _transaction?.Dispose();
                    _connection?.Dispose();
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                _transaction = null;
                _connection = null;

                _disposed = true;
            }
        }

        // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.

        ~UnitOfWork()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
