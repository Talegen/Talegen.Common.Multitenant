﻿/*
 *
 * (c) Copyright Talegen, LLC.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
*/

namespace Talegen.AspNetCore.Multitenant
{
    using System.Threading;

    /// <summary>
    /// This class implements a tenant context accessor for the multi-tenant application.
    /// </summary>
    /// <typeparam name="TTenant">The type of the tenant.</typeparam>
    /// <seealso cref="Talegen.AspNetCore.Multitenant.ITenantContextAccessor{TTenant}" />
    public class TenantContextAccessor<TTenant> : ITenantContextAccessor<TTenant> where TTenant : class, ITenant
    {
        /// <summary>
        /// Gets or sets the tenant context.
        /// </summary>
        /// <value>The tenant context.</value>
        public ITenantContext<TTenant> TenantContext
        {
            get => AsyncLocalContext.Value;
            set => AsyncLocalContext.Value = value;
        }

        /// <summary>
        /// Gets the asynchronous local context
        /// </summary>
        internal static AsyncLocal<ITenantContext<TTenant>> AsyncLocalContext { get; } = new AsyncLocal<ITenantContext<TTenant>>();
    }
}