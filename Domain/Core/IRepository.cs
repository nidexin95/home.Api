using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Core
{
    public interface IRepository<T, in TPrimary> where T : class
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>状态</returns>
        int Add(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据</param>
        /// <returns></returns>
        int Delete(T entity);

        /// <summary>
        /// 更新数据返回个数
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>更新数量</returns>
        int Update(T entity);

        /// <summary>
        /// 根据主键查询对象
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns>数据转换对象</returns>
        T GetEntityByKey(TPrimary id);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="filterExpression">查询条件</param>
        /// <returns>实体</returns>
        IEnumerable<T> Query(Expression<Func<T, bool>> filterExpression = null);
    }
}
