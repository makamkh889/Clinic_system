using clinic.Infrastructure.Data;
using Clinic_managment_System.Clinic_System.Features.DrugHistoryManagment.Repositries;
using Clinic_managment_System.Clinic_System.Features.FollowUpManagment;
using Clinic_managment_System.Clinic_System.Features.InvestigationMangment.Repositries;
using Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment.Repositries;
using Clinic_managment_System.Clinic_System.Features.MedicineMangment.Repositries;
using Clinic_managment_System.Clinic_System.Features.PatientManagment;
using Clinic_managment_System.Clinic_System.Features.TreatmentManagment.Repositries;
using Clinic_managment_System.Clinic_System.Shared.Repository;
namespace InventoryManagmentSystem.Shared.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly ClinicDbContext applicationDBContext;


    private IPatientRepo patientRepo;
    public IPatientRepo Patient
    {
        get
        {
            if (patientRepo is null)
            {
                patientRepo = new PatientRepo(applicationDBContext);
            }
            return patientRepo;
        }
    } 
    private IMedicineRepo medicineRepo;
    public IMedicineRepo Medicine
    {
        get
        {
            if (medicineRepo is null)
            {
                medicineRepo = new MedicineRepo(applicationDBContext);
            }
            return medicineRepo;
        }
    } 

    private IVisitRepo visitRepo;
    public IVisitRepo Visit
    {
        get
        {
            if (visitRepo is null)
            {
                visitRepo = new VisitRepo(applicationDBContext);
            }
            return visitRepo;
        }
    }  
    private IFollowUpRepo followUpRepo;
    public IFollowUpRepo FollowUp
    {
        get
        {
            if (followUpRepo is null)
            {
                followUpRepo = new FollowUpRepo(applicationDBContext);
            }
            return followUpRepo;
        }
    } 
    private ITreatmentRepo treatmentRepo;
    public ITreatmentRepo Treatment
    {
        get
        {
            if (treatmentRepo is null)
            {
                treatmentRepo = new TreatmentRepo(applicationDBContext);
            }
            return treatmentRepo;
        }
    }
    private IMedicalHistoryRepo medicalHistoryRepo;
    public IMedicalHistoryRepo MedicalHistory
    {
        get
        {
            if (medicalHistoryRepo is null)
            {
                medicalHistoryRepo = new MedicalHistoryRepo(applicationDBContext);
            }
            return medicalHistoryRepo;
        }
    }
    private IInvestigationRepo investigationRepo;
    public IInvestigationRepo Investigation
    {
        get
        {
            if (investigationRepo is null)
            {
                investigationRepo = new InvestigationRepo(applicationDBContext);
            }
            return investigationRepo;
        }
    } 
    private IDrugHistoryRepo drugHistoryRepo;
    public IDrugHistoryRepo DrugHistory
    {
        get
        {
            if (drugHistoryRepo is null)
            {
                drugHistoryRepo = new DrugHistoryRepo(applicationDBContext);
            }
            return drugHistoryRepo;
        }
    }

    public UnitOfWork(ClinicDbContext applicationDBContext)
    {
        this.applicationDBContext = applicationDBContext;
    }

    public async Task BeginTransactionAsync()
    {
        await applicationDBContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await applicationDBContext.Database.CommitTransactionAsync();
    }

    public void Dispose()
    {
        applicationDBContext.Dispose();
    }

    public async Task RollbackAsync()
    {
        await applicationDBContext.Database.RollbackTransactionAsync();
    }

    public async Task SaveChangesAsync()
    {
        await applicationDBContext.SaveChangesAsync();
    }
}