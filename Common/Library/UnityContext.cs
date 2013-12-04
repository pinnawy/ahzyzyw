using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Library
{
    public class UnityContext
    {
        /// <summary>
        /// 动态加载BLL类
        /// </summary>
        /// <typeparam name="TBllModel">BLL类别</typeparam>
        /// <returns>BLL类对象</returns>
        public static TBllModel LoadBllModel<TBllModel>()
        {
            IUnityContainer container = new UnityContainer();
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Containers["BllContainer"].Configure(container);

            return container.Resolve<TBllModel>();
        }

        /// <summary>
        /// 动态加载DAL类
        /// </summary>
        /// <typeparam name="TDalModel">BLL类别</typeparam>
        /// <returns>BLL类对象</returns>
        public static TDalModel LoadDalModel<TDalModel>()
        {
            IUnityContainer container = new UnityContainer();
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Containers["DalContainer"].Configure(container);
            return container.Resolve<TDalModel>();
        }
    }
}
