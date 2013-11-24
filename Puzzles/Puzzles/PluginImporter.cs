using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles
{
    /// <summary>
    /// Mechanism to import the various plugins (i.e., puzzles)
    /// </summary>
    public class PluginImporter
    {
        /// <summary>
        /// Gets our collection of plugins
        /// </summary>
        [ImportMany(typeof(IPuzzle))]
        public IEnumerable<IPuzzle> KnownPuzzles { get; private set; }

        /// <summary>
        /// Performs an import of the various plugins
        /// </summary>
        /// <returns>
        /// An importer with the available puzzles already associated to it
        /// </returns>
        public static PluginImporter Import()
        {
            var importer = new PluginImporter();
            var executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var catalog = new AggregateCatalog();

            var targetDirectories = Directory.GetDirectories(
                Path.GetFullPath(
                    Path.Combine(
                        Path.GetDirectoryName(executingAssembly.Location),
                        @"..")));

            catalog.Catalogs.Add(new AssemblyCatalog(executingAssembly));
            foreach (var directory in targetDirectories)
            {
                catalog.Catalogs.Add(new DirectoryCatalog(directory));
            }

            var container = new CompositionContainer(catalog);
            container.ComposeParts(importer);

            return importer;
        }
    }
}
