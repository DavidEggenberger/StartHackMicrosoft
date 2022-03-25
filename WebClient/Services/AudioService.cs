using DTOs.Aggregates.Scenario;
using System;

namespace WebClient.Services
{
    public class AudioService
    {
        public event Action<ScenarioRoleDTO, string> ShowAudioEvent;
        public void ShowAudio(ScenarioRoleDTO role, string location)
        {
            ShowAudioEvent?.Invoke(role, location);  
        }
    }
}
