using AutoMapper;
using Entities.Models;
using Entities.ViewModels;
using System;

namespace Entities.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public override string ProfileName => base.ProfileName;
        public AutoMapperProfile()
        {
        }

        public AutoMapperProfile(string profileName) : base(profileName)
        {
        }

        public AutoMapperProfile(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction)
        {
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString()!;
        }
    }
}