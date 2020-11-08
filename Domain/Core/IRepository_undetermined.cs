using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Core
{
    /// <summary>
    /// 数据仓储
    /// </summary>
    /// <typeparam name="T">实体</typeparam>
    /// <typeparam name="TPrimary">主键类型</typeparam>
    public interface IRepository_undetermined<T, in TPrimary> where T : class
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize();

        /// <summary>
        /// 获取上下文
        /// </summary>
        /// <returns></returns>
        object GetContext();


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>状态</returns>
        int Add(T entity);

        /// <summary>
        /// 不存在则添加
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="wherePredicate"></param>
        /// <returns></returns>
        T AddIfNotExists(T entity, Func<T, bool> wherePredicate);

        /// <summary>
        /// 批量增加
        /// </summary>
        /// <param name="entities">数据集合</param>
        /// <returns></returns>
        int Adds(List<T> entities);

        /// <summary>
        /// 批量增加
        /// </summary>
        /// <param name="entities">可变参数</param>
        /// <returns></returns>
        int Adds(params T[] entities);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据</param>
        /// <returns></returns>
        int Delete(T entity);


        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        void Deletes(IEnumerable<TPrimary> ids);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">实体对象</param>
        /// <returns></returns>
        void Deletes(IEnumerable<T> entity);

        /// <summary>
        /// 根据主键查询对象
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns>数据转换对象</returns>
        T GetEntityByKey(TPrimary id);

        /// <summary>
        /// 获取第一个实体
        /// </summary>
        /// <param name="filterExpression">查询条件</param>
        /// <returns></returns>
        T GetFirstEntity(Expression<Func<T, bool>> filterExpression);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="filterExpression">查询条件</param>
        /// <returns>实体</returns>
        List<T> Query(Expression<Func<T, bool>> filterExpression = null);


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="filterExpression">过滤条件</param>
        /// <param name="targetExpression">转换条件</param>
        /// <param name="orderbyExpression">排序条件</param>        
        /// <param name="isAsc">是否排序</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页记录数</param>
        /// <returns>集合</returns>
        /// <returns>实体</returns>
        List<TTarget> Query<TKey, TTarget>(Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, TTarget>> targetExpression, Expression<Func<T, TKey>> orderbyExpression,
            bool isAsc = true, int pageIndex = -1, int pageSize = 10);




        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="filterExpression">过滤条件</param>
        /// <param name="targetExpression">转换条件</param>
        /// <param name="orderbyExpression">排序条件</param>
        /// <param name="pageTotal">返回总记录数</param>
        /// <param name="isAsc">是否排序</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页记录数</param>
        /// <returns>集合</returns>
        List<T> Query<TKey>(Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, TKey>> orderbyExpression,
            out int pageTotal, bool isAsc = true, int pageIndex = -1, int pageSize = 10);

        /// <summary>
        /// 查询条数
        /// </summary>
        /// <param name="filterExpression">过滤条件</param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> filterExpression);



        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="filterExpression">过滤条件</param>
        /// <param name="orderbyExpression">排序条件</param>
        /// <param name="isAsc">是否排序</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="includeExpressions">连表子查询条件</param>
        /// <returns>集合</returns>
        List<T> QueryPagedEx<TKey>(Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, TKey>> orderbyExpression,
            bool isAsc, int pageIndex, int pageSize,
            params Expression<Func<T, object>>[] includeExpressions);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="filterExpression">过滤条件</param>
        /// <param name="orderbyExpression">排序条件</param>
        /// <param name="isAsc">是否排序</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageTotal">返回总条数</param>
        /// <param name="pageSize">页记录数</param>
        /// <param name="includeExpressions">连表子查询条件</param>
        /// <returns>集合</returns>
        List<T> QueryPagedEx<TKey>(Expression<Func<T, bool>> filterExpression,
                Expression<Func<T, TKey>> orderbyExpression,
                out int pageTotal, bool isAsc, int pageIndex, int pageSize,
                params Expression<Func<T, object>>[] includeExpressions);

        /// <summary>
        /// 更新数据返回个数
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>更新数量</returns>
        int Update(T entity);
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entity">实体集合</param>
        /// <returns>更新数量</returns>
        int Updates(IEnumerable<T> entitys);

        /// <summary>
        /// 更新局部字段返回个数
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>更新数量</returns>
        int UpdatePartialFields(T model, params Expression<Func<T, object>>[] propertiesToUpdate);

        /// <summary>
        /// SQL查询表
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>表数据</returns>
        DataTable QueryBySql(string sql);
    }
}
