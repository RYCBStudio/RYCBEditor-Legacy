using System;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.AvalonEdit.Editing;

namespace IDE;
internal class ErrorAnalysiser
{

    private static List<string> Exceptions = [];
    private static Exception _ex;
    private static string _path;

    internal ErrorAnalysiser(Exception ex, string path)
    {
        _ex = ex;
        _path = path;
    }

    /// <summary>
    /// 获取对应错误的描述
    /// </summary>
    /// <param name="exception">错误类型</param>
    /// <returns>错误描述</returns>
    private static string GetErrorType(Exception exception)
    {

        return exception switch
        {
            FileNotFoundException => $"发生了文件丢失错误({exception.GetType()}): 找不到文件{((FileNotFoundException)exception).FileName}。\n堆栈跟踪: \n{exception.StackTrace}",
            DirectoryNotFoundException => $"发生了文件夹丢失错误({exception.GetType()}): {((DirectoryNotFoundException)exception).Message}\n堆栈跟踪: \n{exception.StackTrace}",
            IndexOutOfRangeException => $"索引超出数组界限。堆栈跟踪: \n{exception.StackTrace}",
            IOException => $"文件操作错误。详细信息: {exception.Message}\n堆栈跟踪: \n{exception.StackTrace}",
            NullReferenceException => $"尝试访问空指针。详细信息: {exception.Message}\n堆栈跟踪: \n{exception.StackTrace}",
            ObjectDisposedException => $"欲操作对象已释放。详细信息: {exception.Message}\n堆栈跟踪: \n{exception.StackTrace}",
            OutOfMemoryException => $"内存溢出。详细信息: {exception.Message}\n堆栈跟踪: \n{exception.StackTrace}",
            OverflowException => $"堆栈溢出。详细信息: {exception.Message}\n堆栈跟踪: \n{exception.StackTrace}",
            UnauthorizedAccessException => $"账户安全错误。请检查你是否将本软件设置于安全软件的白名单中。详细信息: {exception.Message}\n堆栈跟踪: \n{exception.StackTrace}",
            DragDropException => $"拖放文件时发生错误。详细信息: {exception.Message}\n堆栈跟踪: \n{exception.StackTrace}",
            _ => $"未知错误，请复制以下错误信息：\nType: {exception.GetType()}\nMsg: {exception.Message}StackTrace: {exception.StackTrace}",
        };
    }

    /// <summary>
    /// 获取异常数据
    /// </summary>
    /// <returns>异常的列表</returns>
    internal List<string> GetExceptions()
    {
        Exceptions.Clear();
        var __ex = _ex;
        while (__ex.InnerException is not null)
        {
            Exceptions.Add(GetErrorType(__ex));
            __ex = _ex.InnerException;
        }
        Exceptions.Add(GetErrorType(__ex));
        return Exceptions;
    }

    internal void GenerateExceptionInfomation(List<string> exceptions)
    {
        File.WriteAllLines(_path, exceptions);
    }
}
