using majumi.MechanicApp.Model;

namespace majumi.CarService.MechanicsAppService.Rest.Model;

public class MechanicLoginStatus
{
    public bool IsSuccesfull { get; set; }
    public MechanicData? Mechanic { get; set; }

	public MechanicLoginStatus() { }
	public MechanicLoginStatus(bool isSuccesfull, MechanicData? clientData)
	{
		IsSuccesfull = isSuccesfull;
		Mechanic = clientData;
	}
}