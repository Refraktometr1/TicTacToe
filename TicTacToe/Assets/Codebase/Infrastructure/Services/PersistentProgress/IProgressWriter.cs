using Codebase.Data;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
  public interface IProgressWriter : IProgressReader
  {
    void UpdateProgress(PlayerProgress progress);
  }
}