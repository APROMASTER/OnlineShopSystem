
namespace Practica1_programacion2.Application.Core
{
    public abstract class BaseService<TDtoAdd, TDtoMod, TDtoRem>
    {
        public abstract ServiceResult Get();
        public abstract ServiceResult GetById(int id);
        public abstract ServiceResult Save(TDtoAdd model);
        public abstract ServiceResult Update(TDtoMod model);
        public abstract ServiceResult Remove(TDtoRem model);
    }
}
