using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services.OperationStatus;

namespace Umbraco.Cms.Core.Services;

public interface IMemberGroupService : IService
{
    IEnumerable<IMemberGroup> GetAll();

    IMemberGroup? GetById(int id);

    IMemberGroup? GetById(Guid id);

    IEnumerable<IMemberGroup> GetByIds(IEnumerable<int> ids);

    IMemberGroup? GetByName(string? name);

    [Obsolete("Please use the respective CreateAsync/UpdateAsync for you save operations. Scheduled for removal in v15.")]
    void Save(IMemberGroup memberGroup);

    void Delete(IMemberGroup memberGroup);

    /// <summary>
    ///     Creates a new <see cref="IMemberGroup" /> object
    /// </summary>
    /// <param name="memberGroup"><see cref="IMemberGroup" /> to create</param>
    /// <returns>An attempt with a status of whether the operation was successful or not, and the created object if it succeeded.</returns>
    Task<Attempt<IMemberGroup?, MemberGroupOperationStatus>> CreateAsync(IMemberGroup memberGroup);

    /// <summary>
    ///     Deletes a <see cref="IMemberGroup" /> by removing it and its usages from the db
    /// </summary>
    /// <param name="key">The key of the <see cref="IMemberGroup" /> to delete</param>
    Task<Attempt<IMemberGroup?, MemberGroupOperationStatus>> DeleteAsync(Guid key);

    /// <summary>
    ///     Updates <see cref="IMemberGroup" /> object
    /// </summary>
    /// <param name="memberGroup"><see cref="IMemberGroup" /> to create</param>
    /// <returns>An attempt with a status of whether the operation was successful or not, and the object.</returns>
    Task<Attempt<IMemberGroup?, MemberGroupOperationStatus>> UpdateAsync(IMemberGroup memberGroup);
}
