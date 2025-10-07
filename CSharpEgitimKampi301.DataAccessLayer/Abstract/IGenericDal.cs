using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class // sadece sınıflarla çalışmak için
    {
        void Insert(T entity); //ekleme
        void Update(T entity); //güncelleme
        void Delete(T entity); //silme
        List<T> GetAll(); //listeleme
        T GetById(int id); //id'ye göre getirme
    }
}
