using Clinic_managment_System.Clinic_System.Features.DrugHistoryManagment.Repositries;
using Clinic_managment_System.Clinic_System.Features.FollowUpManagment;
using Clinic_managment_System.Clinic_System.Features.InvestigationMangment.Repositries;
using Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment.Repositries;
using Clinic_managment_System.Clinic_System.Features.MedicineMangment.Repositries;
using Clinic_managment_System.Clinic_System.Features.PatientManagment;
using Clinic_managment_System.Clinic_System.Features.TreatmentManagment.Repositries;
using Clinic_managment_System.Clinic_System.Shared.Repository;

namespace InventoryManagmentSystem.Shared.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    public IPatientRepo Patient { get; }
    public IMedicineRepo Medicine { get; }
    public IVisitRepo Visit { get; }
    public IFollowUpRepo FollowUp { get; }
    public IDrugHistoryRepo DrugHistory { get; }
    public ITreatmentRepo Treatment { get; }
    public IMedicalHistoryRepo MedicalHistory { get; }
    public IInvestigationRepo Investigation { get; }
    Task SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}