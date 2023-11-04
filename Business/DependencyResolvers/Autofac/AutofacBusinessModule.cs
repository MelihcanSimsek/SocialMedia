﻿using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<ChatManager>().As<IChatService>();
            builder.RegisterType<FavManager>().As<IFavService>();
            builder.RegisterType<FollowerManager>().As<IFollowerService>();
            builder.RegisterType<NotificationManager>().As<INotificationService>();
            builder.RegisterType<PostManager>().As<IPostService>();
            builder.RegisterType<PostTagManager>().As<IPostTagService>();
            builder.RegisterType<ProfileManager>().As<IProfileService>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserTagManager>().As<IUserTagService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<EfChatDal>().As<IChatDal>();
            builder.RegisterType<EfFavDal>().As<IFavDal>();
            builder.RegisterType<EfFollowerDal>().As<IFollowerDal>();
            builder.RegisterType<EfNotificationDal>().As<INotificationDal>();
            builder.RegisterType<EfPostDal>().As<IPostDal>();
            builder.RegisterType<EfPostTagDal>().As<IPostTagDal>();
            builder.RegisterType<EfProfileDal>().As<IProfileDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfUserTagDal>().As<IUserDal>();


        }
    }
}
