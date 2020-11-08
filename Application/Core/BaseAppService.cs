using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Core;
using Infrastructure.EntityFrameWorkCore.SQLServer;
using Microsoft.EntityFrameworkCore;

namespace Application.Core
{
    public abstract class BaseAppService<T, TDto, TPrimaryKey> : IBaseAppService<T, TDto, TPrimaryKey> where T: class where TDto : class
    {
        /// <summary>
        /// 数据仓储对象
        /// </summary>
        private readonly IRepository<T, TPrimaryKey> _repository;

        private readonly WkBillContext _wkBillContext;
        private readonly IMapper _mapper;

        protected BaseAppService(IRepository<T, TPrimaryKey> repository,WkBillContext wkBillContext,IMapper mapper)
        {
            _repository = repository;
            _wkBillContext = wkBillContext;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Add(TDto entity)
        {
            var t = _mapper.Map<TDto, T>(entity);
            _wkBillContext.Add(t);
        }

        public void Delete(TDto entity)
        {
            var t = _mapper.Map<TDto, T>(entity);
            _wkBillContext.Remove(t);
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">TDto</param>
        public void Update(TDto entity)
        {
            var t = _mapper.Map<TDto, T>(entity);
            _wkBillContext.Update(t);
        }
        /// <summary>
        /// 判断实体是否存在
        /// </summary>
        /// <param name="id">实体ID</param>
        /// <returns></returns>
        public async Task<bool> GetHasEntity(TPrimaryKey id)
        {
            var t = await _wkBillContext.FindAsync<T>(id);
            return t != null;
        }
        public TDto GetEntityByKey(TPrimaryKey id)
        {
            var t = _wkBillContext.Find<T>(id);
            if (t == null) return null;
            var dto = _mapper.Map<T, TDto>(t);
            return dto;
        }

        public IEnumerable<TDto> Query(Expression<Func<T, bool>> filterExpression = null)
        {
            var query = _wkBillContext.Set<T>().AsQueryable();
            if (filterExpression != null)
            {
                query = query.Where(filterExpression);
            }

            var tList = query.ToList();
            var list = _mapper.Map<IEnumerable<T>,IEnumerable<TDto>>(tList);
            return list;
        }

        public async Task<IEnumerable<TDto>> QueryAsync(Expression<Func<T, bool>> filterExpression = null)
        {
            var query = _wkBillContext.Set<T>().AsQueryable();
            if (filterExpression != null)
            {
                query = query.Where(filterExpression);
            }

            var tList = await query.ToListAsync();
            var list = _mapper.Map<IEnumerable<T>, IEnumerable<TDto>>(tList);
            return list;
        }

        public int SaveChanges()
        {
            return _wkBillContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _wkBillContext.SaveChangesAsync();
        }
    }
}
