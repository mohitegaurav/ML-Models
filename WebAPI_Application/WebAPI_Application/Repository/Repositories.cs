using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Application.Models;

namespace WebAPI_Application.Repository
{
    public interface IRepository<TEntity, TPk> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TPk id);
        TEntity Create(TEntity entity);
        bool Update(TPk id, TEntity entity);
        bool Delete(TPk id);
    }

    public class DepartmentRepository : IRepository<Department, int>
    {
        ApplicationEntities ctx;

        public DepartmentRepository()
        {
            ctx = new ApplicationEntities();
        }

        public Department Create(Department entity)
        {
            ctx.Department.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var dept = ctx.Department.Find(id);
            if (dept != null)
            {
                ctx.Department.Remove(dept);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Department> Get()
        {
            var dept = ctx.Department.ToList();
            return dept;
        }

        public Department Get(int id)
        {
            var dept = ctx.Department.Find(id);
            return dept;
        }

        public bool Update(int id, Department entity)
        {
            var dept = ctx.Department.Find(id);
            if (dept != null)
            {
                dept.DeptNo = entity.DeptNo;
                dept.DeptName = entity.DeptName;
                dept.Location = entity.Location;
                dept.Capacity = entity.Capacity;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }

    public class EmployeeRepository : IRepository<Employee, int>
    {
        ApplicationEntities ctx;
        public EmployeeRepository()
        {
            ctx = new ApplicationEntities();
        }

        public Employee Create(Employee entity)
        {
            ctx.Employee.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var emp = ctx.Employee.Find(id);
            if (emp != null)
            {
                ctx.Employee.Remove(emp);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Employee> Get()
        {
            return ctx.Employee.ToList();
        }

        public Employee Get(int id)
        {
            return ctx.Employee.Find(id);
        }

        public bool Update(int id, Employee entity)
        {
            var emp = ctx.Employee.Find(id);
            if (emp != null)
            {
                emp.EmpNo = entity.EmpNo;
                emp.EmpName = entity.EmpName;
                emp.Salary = entity.Salary;
                emp.Designation = entity.Designation;
                emp.DeptUniqueId = entity.DeptUniqueId;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}