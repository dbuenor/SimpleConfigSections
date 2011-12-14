﻿using System;
using Castle.DynamicProxy;
using SimpleConfigSections.BasicExtensions;

namespace SimpleConfigSections
{
    internal class ConcreteConfiguration : IInterceptor
    {
        private readonly IConfigValue _configValue;
        private readonly ProxyGenerator _proxyGenerator;

        public ConcreteConfiguration(IConfigValue configValue)
        {
            _configValue = configValue;
            _proxyGenerator = new ProxyGenerator();
        }


        public void Intercept(IInvocation invocation)
        {
            object obj = _configValue.Value(invocation.Method.PropertyName());
            invocation.ReturnValue = obj;
        }


        public object ClientValue(Type interfaceType)
        {
            return _proxyGenerator.CreateInterfaceProxyWithoutTarget(interfaceType, this);
        }
    }

    internal class ConcreteConfiguration<T> : ConcreteConfiguration where T : class
    {
        public ConcreteConfiguration(ConfigurationSection<T> section)
            : base(section)
        {
        }

        public T ClientValue()
        {
            return (T)base.ClientValue(typeof(T));
        }
    }
}