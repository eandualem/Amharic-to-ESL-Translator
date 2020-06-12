using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
//using System.Text;


public class ESLSocketClient {
    private static ManualResetEvent connectDone = new ManualResetEvent(false);
    private static ManualResetEvent sendDone = new ManualResetEvent(false);
    private static ManualResetEvent receiveDone = new ManualResetEvent(false);
    
    public ESLSocketClient() {
        
    }
    
    public static Socket getClient(IPAddress ipAddr) {
        Socket client = null;
        try {
            client = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            return client;
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString());
            return client;
        }
    }
    public static void connect(Socket client, IPAddress ipAddr, int port) {
        try {
            IPEndPoint ep = new IPEndPoint(ipAddr, port);
            AsyncCallback callbackObj = new AsyncCallback(connectCallback);
            client.BeginConnect(ep, callbackObj, client);
            
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString());
        }
        connectDone.WaitOne();
        
    }
    private static void connectCallback(IAsyncResult ar) {
        try {
            Socket client = (Socket) ar.AsyncState;
            client.EndConnect(ar);
            // conection establshed
            connectDone.Set();
            // signaling that connection has been made;
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString());
        }
       
        
    }
    public static void send(Socket client, string data) {
        byte[] byteData = Encoding.ASCII.GetBytes(data);
        AsyncCallback callbackObj = new AsyncCallback(sendCallback);
        client.BeginSend(byteData, 0, byteData.Length, 0, callbackObj, client);
        
        
    }
    private static void sendCallback(IAsyncResult ar) {
        try {
            Socket client = (Socket) ar.AsyncState;
            // compelete sending
            int sentByte = client.EndSend(ar);
            // signaling
            sendDone.Set();
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString());
        }
    }
    public static void receive(Socket client) {
        try {
            StateObject stateObj = new StateObject();
            stateObj.socket = client;
            AsyncCallback callbackObj = new AsyncCallback(receiveCallback);
            client.BeginReceive(stateObj.buffer, 0, stateObj.bufferSize, 0, callbackObj, stateObj);
            
        } catch (Exception ex){
            Console.WriteLine(ex.ToString());
        }
    }
    private static void receiveCallback(IAsyncResult ar) {
        try {
            StateObject stateObj = (StateObject) ar.AsyncState;
            Socket client = stateObj.socket;
            int bytesRead = client.EndReceive(ar);
            if (bytesRead > 0) {
                string strData = Encoding.ASCII.GetString(stateObj.buffer, 0, bytesRead);
                stateObj.sb.Append(strData);
                AsyncCallback callbackObj = new AsyncCallback(receiveCallback);
                client.BeginReceive(stateObj.buffer, 0, stateObj.bufferSize, 0, callbackObj, stateObj);
            } else {
                if (stateObj.sb.Length > 1) {
                    string response = stateObj.sb.ToString();
                }
                receiveDone.Set();
            }
            
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString());
        }
    }
    
    public static IPAddress resolveIp(string domainName) {
        IPAddress ipAddr = null;
        try {
            IPHostEntry ipInfo = Dns.GetHostEntry(domainName);
            ipAddr = ipInfo.AddressList[0];
            return ipAddr;
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString());
            return ipAddr;
        }
    }
    public static void Main(string[] args) {
        // todo testing
        //Console.WriteLine(ESLSocketClient.getClient(resolveIp("localhost")));
    }
}
public class StateObject {
    public Socket socket = null;
    public int bufferSize = 256;
    public byte[] buffer = new byte[256];
    public StringBuilder sb = new StringBuilder();
}
