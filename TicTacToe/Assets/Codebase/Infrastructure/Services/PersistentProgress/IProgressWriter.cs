using Codebase.Data;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
  public interface IProgressWriter
  {
    void UpdateProgress(PlayerProgress progress);
  }
}