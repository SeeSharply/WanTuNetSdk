/*
 * author eleven  康宇
 * date 2016.3.25
 *说明
 *此类用作返回body参数作用，最终会解析为json，
 * 属性名字可以自己更具自己项目重新定义
 * 在创建类的时候，需要使用属性，只用赋值一个随意的不为null值就行了
 * 属性中有两个参数没有涉及，分别是
 * 自定义占位符var-* ：用户自定义占位符("var-"为参数前缀, "*"为用户用于渲染的自定义占位符名)，包含在上传参数中
 * 自定义元信息meta-*：用户自定义的文件meta信息("meta-"为参数前缀, "*"为用户用于渲染的自定义Meta信息名) ，包含在上传参数中
 * 这两个参数需要自己设计在上传策略中，开发者请参考官方文档
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WanTuNetSdk.common
{
    /// <summary>
    /// 在创建类的时候，需要使用某一个属性，只用赋值一个随意的不为null值就行了
    /// </summary>
    public class ReturnBody
    {

        private string _nameSpace;
        /// <summary>
        /// 开发者创建空间时指定的空间唯一标示
        /// </summary>
        public string nameSpace
        {
            get { return _nameSpace; }
            set
            {
                _nameSpace= string.IsNullOrEmpty(value)?null:"${namespace}";
            }
        }

        private string _dir;
        /// <summary>
        /// 文件路径(不可以用来渲染dir和name)
        /// </summary>
        public string dir 
        {
            get { return _dir; }
            set
            {
                _dir = string.IsNullOrEmpty(value) ? null : "${dir}";
            }
        }
        private string _mimeType;

        /// <summary>
        /// 文件类型(MimeType) (中间有'/', 请不要用于渲染name)
        /// </summary>
        public string mimeType
        {
            get { return _mimeType; }
            set
            {
                _mimeType = string.IsNullOrEmpty(value) ? null : "${mimeType}";
            }
        }

        private string _mediaType;
        /// <summary>
        /// 文件MIME前缀, 多媒体文件类型(取自MimeType)
        /// </summary>
        /// 
        public string mediaType 
        {
            get { return _mediaType; } 
            set
            {
                _mediaType = string.IsNullOrEmpty(value) ? null : "${mediaType}";
            }
        }

        private string _ext;
        /// <summary>
        /// 文件MIME后缀, 文件扩展名(取自MimeType)
        /// </summary>
        public string ext 
        {
            get { return _ext; }
            set
            {
                _ext = string.IsNullOrEmpty(value) ? null : "${ext}";
            }
        }

        private string _year;
        /// <summary>
        /// 上传时间的年份
        /// </summary>
        /// 
        public string  year 
        {
            get { return _year; }
            set
            {
                _year = string.IsNullOrEmpty(value) ? null : "${year}";
            }
        }
        private string _month;
        /// <summary>
        /// 上传时间的月份
        /// </summary>
        /// 
        public string month
        {
            get { return _month; }
            set
            {
                _month = string.IsNullOrEmpty(value) ? null : "${month}";
            }
        }

        private string _day;
        /// <summary>
        /// 上传时间的日期
        /// </summary>
        public string day
        {
            get { return _day; }
            set
            {
                _day = string.IsNullOrEmpty(value) ? null : "${day}";
            }
        }

        private string _hour;
        /// <summary>
        /// 上传时间的小时(24小时制)
        /// </summary>
        public string hour
        {
            get { return _hour; }
            set
            {
                _hour = string.IsNullOrEmpty(value) ? null : "${hour}";
            }
        }
        private string _minute;
        /// <summary>
        /// 上传时间的分
        /// </summary>
        public string minute
        {
            get { return _minute; }
            set
            {
                _minute = string.IsNullOrEmpty(value) ? null : "${minute}";
            }
        }

        private string _second;
        /// <summary>
        /// 上传时间的秒
        /// </summary>
        public string second
        {
            get { return _second; }
            set
            {
                _second = string.IsNullOrEmpty(value) ? null : "${second}";
            }
        }
        private string _fileSize;
        /// <summary>
        /// 文件大小
        /// </summary>
        public string fileSize
        {
            get { return _fileSize; }
            set
            {
                _fileSize = string.IsNullOrEmpty(value) ? null : "${fileSize}";
            }
        }
        private string _uuid;
        /// <summary>
        ///生成的uuid
        /// </summary>
        public string uuid
        {
            get { return _uuid; }
            set
            {
                _uuid = string.IsNullOrEmpty(value) ? null : "${uuid}";
            }
        }
        private string _width;
        /// <summary>
        /// 图片宽
        /// </summary>
        public string  width
        {
            get { return _width; }
            set
            {
                _width = string.IsNullOrEmpty(value) ? null : "${width}";
            }
        }
        private string _height;
        /// <summary>
        /// 图片高
        /// </summary>
        public string  height
        {
            get { return _height; }
            set
            {
                _height = string.IsNullOrEmpty(value) ? null : "${height}";
            }
        }
        private string _exif;
        /// <summary>
        /// 图片的Exif信息，里面包含了诸多子项，可以通过exif.xxx来获取
        /// </summary>
        public string exif
        {
            get { return  _exif; }
            set
            {
                _exif = string.IsNullOrEmpty(value) ? null : "${exif}";
            }
        }
    }
}