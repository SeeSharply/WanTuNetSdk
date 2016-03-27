/*
 * author eleven  康宇
 * date 2016.3.25
 *说明
 *为了保证没设置的参数不上传，考虑到json.net序列化问题，故意将所有属性采用stirng类型
 *其中，expiration和insertonly，namespace为必传项
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WanTuNetSdk.common
{
    public class PhotoPolicy
    {
        /// <summary>
        /// 云空间秘制
        /// </summary>
        public string  NameSpace { get; set; }
        /// <summary>
        /// 时长
        /// </summary>
        private string _expiration;
        public string expiration
        {
            get { return this._expiration;}
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this._expiration = "-1";
                }
                else
                {
                    this._expiration = value;
                }
            }
        }

        public string dir { get; set; }
        /// <summary>
        /// 文件名，默认使用uuid
        /// </summary>
        private string _name;
        public string name {
            get { return _name; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    _name = "${uuid}";
                }
                else
                {
                    _name = value;
                }
        } }
        /// <summary>
        /// 指定上传文件大小的最大值(单位:字节)
        /// 各种资源类型文件大小的系统限制
        /// 图片: 10485760 (10Mb: 10 * 1024 * 1024)，
        /// 默认情况下使用系统限制检查文件大小
        /// </summary>
        private long _sizeLimit;
        public long sizeLimit {
            get { return _sizeLimit; }
            set {
                if (value<=0)
                {
                    _sizeLimit = 10 * 1024 * 1024;
                }
                else
                {
                    _sizeLimit = value;
                }
            }
        }
        /// <summary>
        /// 指定上传文件类型的限制(MimeType类型)
        /// </summary>
        public string mimeLimit { get; set;}

        /// <summary>
        /// 图片上传完成之后,系统回调该Url
        /// </summary>
        /// 
        public string callbackUrl { get; set; }
        /// <summary>
        /// 在系统回调时,将设置请求头部的Host信息,设置该参数之前应该首先设置callbackUrl
        /// </summary>
        public string callbackHost { get; set; }

        /// <summary>
        /// 在系统回调时,将设置请求的Body信息
        /// 设置该参数之前应该首先设置callbackUrl
        /// 该参数可以包含占位符
        /// </summary>
        public string callbackBody { get; set; }
        /// <summary>
        /// 在系统回调时,将设置请求的Body类型
        /// 设置该参数之前应该首先设置callbackUrl
        /// 设置该参数之前应该首先设置callbackBody
        /// </summary>
        public string callbackBodyType { get; set; }

        /// <summary>
        /// 默认为0
        /// </summary>
        public int insertOnly { get; set; }

        /// <summary>
        /// 是否自动检查文件头部信息0: 不自动检查, 1: 自动检查
        /// </summary>
        public string detectMime { get; set; }

        /// <summary>
        /// 上传完成之后,303跳转的Url
        /// </summary>
        public string returnUrl { get; set; }

        /// <summary>
        /// 上传完成之后,返回的Body信息,该参数可以包含占位符
        /// </summary>
        public ReturnBody returnBody { get; set; }

    }
}