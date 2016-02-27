using TakeALook.Model;
using TakeALook.Model.Interface;
using TakeALook.Operation.Interface;
using TakeALook.Repository;
using TakeALook.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Operation
{
    public class ReportTemplateOperations : OperationsBase, IReportTemplateOperations
    {
        private IRepository<ChartDemogColumn> m_ChartDemogColumnRepository;
        private IRepository<ReportChartComponent> m_ReportChartComponentRepository;
        private IRepository<NameValueDemogColumn> m_NameValueDemogRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        public ReportTemplateOperations()
            : base(DBContextCreationOptions.TakeALookDBContext)
        {
            m_ChartDemogColumnRepository = m_UnitOfWork.Repository<ChartDemogColumn>();
            m_ReportChartComponentRepository = m_UnitOfWork.Repository<ReportChartComponent>();
            m_NameValueDemogRepository = m_UnitOfWork.Repository<NameValueDemogColumn>();
        }

        /// <summary>
        /// Hangi chartta hangi demografik kolonların kullanılacağı bilgisi
        /// </summary>
        /// <param name="chartID"></param>
        /// <returns></returns>
        public IEnumerable<IChartDemogColumn> GetDemogColumns(int chartID)
        {
            return m_ChartDemogColumnRepository.GetMany(x => x.ChartID == chartID);
        }

        /// <summary>
        /// Chart templatei
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IReportChartComponent> GetChartComponents()
        {
            IEnumerable<IReportChartComponent> components = m_ReportChartComponentRepository.GetAll();
            foreach (var component in components)
            {
                component.DemogColumns = GetDemogColumns(component.ID);
            }
            return components;
        }

        public IEnumerable<INameValueDemogColumn> GetNameValueDemogColumns() 
        {
            return m_NameValueDemogRepository.GetAll();
        }

        /// <summary>
        /// Templatein tamamı
        /// </summary>
        /// <returns></returns>
        public IReportTemplate GetTemplate() 
        {
            return new ReportTemplate()
            {
                ChartComponents = GetChartComponents(),
                NameValueComponents = GetNameValueDemogColumns()
            };
        }
    }
}
