using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        CampContext context = new CampContext();
        private readonly DbSet<T> _object;
        public GenericRepository()
        {
            _object = context.Set<T>(); // genericrepository çağırıldığında onject değerine context sınıfından gönderilen entity atanır
        }
        public void Delete(T entity)
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted; // state komutu ile ekleme silme ve güncelleme işlemlerini yapabiliriz
            context.SaveChanges();//değişklikleri kaydet
        }

        public List<T> GetAll()
        {
            return _object.ToList(); // tüm verileri getirme
        }

        public T GetById(int id)
        {
            return _object.Find(id); //id'ye göre getir
        }

        public void Insert(T entity)
        {
            var addedEntity = context.Entry(entity);//ekleme işlemi yapacağımız entitiyi hafızaya çektik
            addedEntity.State = EntityState.Added;//ekleme işlemi
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;//güncelleme işlemi. modified .net framework'teki update işlemidir
            context.SaveChanges();
        }
    }
}
