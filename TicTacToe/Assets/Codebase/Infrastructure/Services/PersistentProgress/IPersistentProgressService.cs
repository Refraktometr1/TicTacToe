using Codebase.Data;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
  public interface IPersistentProgressService
  {
    PlayerProgress Progress { get; set; }
  }
}