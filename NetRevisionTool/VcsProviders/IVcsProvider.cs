﻿using System;
using System.Linq;

namespace NetRevisionTool.VcsProviders
{
	internal interface IVcsProvider
	{
		/// <summary>
		/// Gets the name of the provider. This name can be compared with the /require option.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Checks whether the environment requirements are met for the VCS provider to run.
		/// </summary>
		/// <returns>true if the VCS provider can be used, otherwise false.</returns>
		/// <remarks>
		/// Most VCS providers require external tools to be installed to process a directory. This
		/// method checks whether these tools are installed, if any. It must be called once before
		/// calling other methods.
		/// </remarks>
		bool CheckEnvironment();

		/// <summary>
		/// Checks whether the specified directory is a valid working directory for the VCS provider.
		/// </summary>
		/// <param name="path">The directory to check.</param>
		/// <param name="rootPath">The detected working directory root path.</param>
		/// <returns>true if the VCS provider can process the directory, otherwise false.</returns>
		bool CheckDirectory(string path, out string rootPath);

		/// <summary>
		/// Processes the specified directory.
		/// </summary>
		/// <param name="path">The directory to process.</param>
		/// <returns>The data about the revision found in the directory.</returns>
		RevisionData ProcessDirectory(string path, string repoRoot);
	}
}
