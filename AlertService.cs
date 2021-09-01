//Refactor the AlertService and AlertDAO classes:
//1. Create a new interface, named IAlertDAO, that contains the same methods as AlertDAO.
//2. AlertDAO should implement the IAlertDAO interface.
//3. AlertService should have a constructor that accepts IAlertDAO.
//4. The RaiseAlert and GetAlertTime methods should use the object passed through the constructor.

===============================================================================

using System.Collections.Generic;
using System;

public class AlertService	
{
    private readonly IAlertDAO storage;
 

    public AlertService(IAlertDAO alert)
    {
        storage = alert;
    }
    
    public Guid RaiseAlert()
    {
        
        return this.storage.AddAlert(DateTime.Now);
    }
	
    public DateTime GetAlertTime(Guid id)
    {
        return this.storage.GetAlert(id);
    }	
}

public class AlertDAO : IAlertDAO
{
    private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();
	
    public Guid AddAlert(DateTime time)
    {
        Guid id = Guid.NewGuid();
        this.alerts.Add(id, time);
        return id;
    }
	
    public DateTime GetAlert(Guid id)
    {
        return this.alerts[id];
    }	
}

public interface IAlertDAO
{
    Guid AddAlert(DateTime time);
    DateTime GetAlert(Guid id);
}

    




