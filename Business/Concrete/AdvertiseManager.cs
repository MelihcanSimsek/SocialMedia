using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdvertiseManager : IAdvertiseService
    {
        IAdvertiseDal _advertiseDal;
        IUserTagService _userTagService;
        public AdvertiseManager(IAdvertiseDal advertiseDal, IUserTagService userTagService)
        {
            _advertiseDal = advertiseDal;
            _userTagService = userTagService;
        }
        public IResult Add(IFormFile file, Advertise advertise)
        {
            if(file != null)
            {
                advertise.ImagePath = FileHelper.Add(file);
            }
            advertise.CreationDate = DateTime.Now;
            _advertiseDal.Add(advertise);
            return new SuccessResult();
        }

        public IDataResult<Advertise> GetUserMainAdvertiseByUserId(int userId)
        {
            var userLabels = _userTagService.GetAllUserLabelForWeekByUserId(userId).Data;
            if (userLabels.Count == 0)
            {
                return new SuccessDataResult<Advertise>(null,Messages.UserHasNotLabel);
            }
            var mostRepeatedLabel = GetMostRepeatedWord(userLabels);
            var advetiseList = _advertiseDal.GetAll(p => p.Label.Trim() == mostRepeatedLabel.Trim() && p.EndDate > DateTime.Now && p.Type == 1 );
            var selectedAdvertise = advetiseList[new Random().Next(advetiseList.Count)];
            return new SuccessDataResult<Advertise>(selectedAdvertise);
        }

        public IDataResult<Advertise> GetUserSideAdvertiseByUserId(int userId)
        {
            var userLabels = _userTagService.GetAllUserLabelForWeekByUserId(userId).Data;
            if (userLabels.Count == 0)
            {
                return new SuccessDataResult<Advertise>(null, Messages.UserHasNotLabel);
            }
            var mostRepeatedLabel = GetMostRepeatedWord(userLabels);
            var advetiseList = _advertiseDal.GetAll(p => p.Label.Trim() == mostRepeatedLabel.Trim() && p.EndDate > DateTime.Now && p.Type == 2);
            var selectedAdvertise = advetiseList[new Random().Next(advetiseList.Count)];
            return new SuccessDataResult<Advertise>(selectedAdvertise);
        }

        private string GetMostRepeatedWord(List<string> labels)
        {
            Dictionary<string, int> wordFreq = new Dictionary<string, int>();
            foreach (var label in labels)
            {
                if(wordFreq.ContainsKey(label))
                {
                    wordFreq[label]++;
                }
                else
                {
                    wordFreq[label] = 1;
                }
            }

            int maxFeq = wordFreq.Max(x => x.Value);

            var mostRepeatedWords = wordFreq.Where(x => x.Value == maxFeq).Select(x => x.Key).ToList();

            if(mostRepeatedWords.Count == 1)
            {
                return mostRepeatedWords[0];
            }
            else
            {
                return mostRepeatedWords[new Random().Next(0, mostRepeatedWords.Count)];
            }



           
        }
    }
}
