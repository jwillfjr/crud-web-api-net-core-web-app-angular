using ExampleCRUD.Domain.IUnitOfWords;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCRUD.Application.Services
{
    public class AppServiceBase<TEntity, TIService>
        where TEntity : class
        where TIService : Domain.IServices.IServiceBase<TEntity>
    {
        protected readonly TIService _service;
        protected readonly IUnitOfWord _unitOfWork;

        public AppServiceBase(TIService service, IUnitOfWord unitOfWork)
        {
            _service = service;
            _unitOfWork = unitOfWork;
        }
        public virtual async Task<TEntity> Add(TEntity entity)
        {
            try
            {
                var inTransaction = true;
                if (_unitOfWork.Transaction == null)
                {
                    inTransaction = false;
                    _unitOfWork.BeginTransaction();
                }

                var result = await _service.Add(entity, _unitOfWork.Transaction);

                if (!inTransaction)
                    _unitOfWork.Commit();

                return result;

            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                throw e;
            }

        }

        public virtual async Task<bool> Delete(dynamic id)
        {
            try
            {
                var inTransaction = true;
                if (_unitOfWork.Transaction == null)
                {
                    inTransaction = false;
                    _unitOfWork.BeginTransaction();
                }

                var result = await _service.Delete(id, _unitOfWork.Transaction);


                if (!inTransaction)
                    _unitOfWork.Commit();

                return result;

            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                throw e;
            }
        }

        public virtual async Task<TEntity> Get(dynamic id)
        {
            try
            {
                var result = await _service.Get(id, _unitOfWork.Transaction);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public virtual async Task<bool> Update(TEntity entity)
        {
            try
            {
                var inTransaction = true;
                if (_unitOfWork.Transaction == null)
                {
                    inTransaction = false;
                    _unitOfWork.BeginTransaction();
                }

                var result = await _service.Update(entity, _unitOfWork.Transaction);


                if (!inTransaction)
                    _unitOfWork.Commit();

                return result;

            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                throw e;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> Get(object predicate, int page, int resultsPerPage)
        {
            try
            {
                return await _service.Get(predicate, page, resultsPerPage, _unitOfWork.Transaction);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
