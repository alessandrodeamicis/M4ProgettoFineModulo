using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Project.Scripts
{
    public interface IBulletSpawner
    {
        public virtual void ReleaseBullet(Bullet bullet)
        {
        }
    }
}
