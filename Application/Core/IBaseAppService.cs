using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public interface IBaseAppService<T, TDto, TPrimaryKey> where T : class where TDto : class

    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>状态</returns>
        void Add(TDto entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据</param>
        /// <returns></returns>
        void Delete(TDto entity);

        /// <summary>
        /// 更新数据返回个数
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>更新数量</returns>
        void Update(TDto entity);

        /// <summary>
        /// 根据主键查询对象
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns>数据转换对象</returns>
        TDto GetEntityByKey(TPrimaryKey id);

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns>实体</returns>
        IEnumerable<TDto> Query(Expression<Func<T, bool>> filterExpression = null);

        /// <summary>
        /// 异步查询
        /// </summary>
        /// <returns>实体</returns>
        Task<IEnumerable<TDto>> QueryAsync(Expression<Func<T, bool>> filterExpression = null);
        int SaveChanges();
        Task<int> SaveChangesAsync();

        Task<bool> GetHasEntity(TPrimaryKey id);
    }
}
