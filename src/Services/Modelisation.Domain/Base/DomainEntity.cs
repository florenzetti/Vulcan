namespace Modelisation.Domain.Base
{
    public abstract class DomainEntity
    {
        private int _id;

        public virtual int Id
        {
            get { return _id; }
            protected set { _id = value; }
        }
    }
}
