﻿namespace Unosquare.Labs.EmbedIO
{
    using Constants;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
#if NET47
    using System.Net;
#else
    using Net;
#endif
    
    /// <summary>
    /// Interface to create web modules
    /// </summary>
    public interface IWebModule
    {
        /// <summary>
        /// Gets the friendly name of the module.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the handlers.
        /// </summary>
        /// <value>
        /// The handlers.
        /// </value>
        ModuleMap Handlers { get; }
        
        /// <summary>
        /// Gets the server owning this module. This property is set automatically after registering the module.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        WebServer Server { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is watchdog enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is watchdog enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsWatchdogEnabled { get; set; }

        /// <summary>
        /// Gets or sets the watchdog interval.
        /// </summary>
        /// <value>
        /// The watchdog interval.
        /// </value>
        TimeSpan WatchdogInterval { get; set; }

        /// <summary>
        /// Adds a handler that gets called when a path and verb are matched.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="verb">The verb.</param>
        /// <param name="handler">The handler.</param>
        void AddHandler(string path, HttpVerbs verb, Func<HttpListenerContext, CancellationToken, Task<bool>> handler);

        /// <summary>
        /// Runs the watchdog.
        /// </summary>
        void RunWatchdog();
    }
}
