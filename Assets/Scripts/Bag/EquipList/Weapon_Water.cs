using UnityEngine;

namespace FireControl.Equip
{
    public class Weapon_Water : Weapon
    {
        public float suviverTime;
        public float waterGunforce = 5f;
        public Weapon_Water()
        {
            Initialize();
        }

        public override EquipReturn WeaponBehavior(Bag bag)
        {
            equipNeogor--;
            //if(particleWater == null)
            //{
            //    particleWater = Common.CommonFunction.GetComponentInChild<Common.ParticleSystem.ParticleWater>(bag.transform);
            //}
            EquipReturn equipReturn = new EquipReturn();
            //����Ŀǰ����û������Ч�������Բ��ܣ�֮��һЩװ����Ҫ����
            //buff���������
            equipReturn.addState = null;
            //�������Ƿ��˺�������ͬʱ��ʵһ����˺�Ҳ����������ӵ�
            //��������Ƶ��߲���Ҫ�����ﷵ�ط���ֵ
            equipReturn.value = attackValue;
            //if(particleWater == null)
            //{
            //    Debug.Log("û�ҵ�");
            //    return equipReturn;
            //}

            //particleWater.RayWater();

            return equipReturn;
        }

        protected override void Initialize()
        {
            this.equipID = 0;
            this.attackValue = 0;
            this.suviverTime = 4f;
            this.equipType = EquipType.Weapon;
            this.equipName = "ˮǹ";
            this.equipIntroduce = "һ��ʮ��ţ�Ƶ�ˮǹ";
            this.maxNeogor = 100;
            this.equipNeogor = 0;
            this.className = "Weapon_Water";
        }
    }
}