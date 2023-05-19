using Codebase.Data;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
  public interface IProgressReader
  {
    void LoadProgress(PlayerProgress progress);
  }
}