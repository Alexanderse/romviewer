using System.Net.Sockets;
using System.Threading;

namespace RomService.Library
{
	/// <summary>
	/// Summary description for ClientSocketListener.
	/// </summary>
	public class ClientSocketListener
	{
		private Socket m_clientSocket = null;
		public ClientSocketListener(Socket clientSocket)
		{
			m_clientSocket = clientSocket;
		}

		public void StartClientListener()
		{
			Thread clientListenerThread = 
				new Thread(new ThreadStart(ClientListenerThreadStart));
		}

		private void ClientListenerThreadStart()
		{
			while (m_clientSocket.Connected)
			{

			}
		}

		public void StopClientListener()
		{
			if (m_clientSocket != null)
			{
				m_clientSocket.Close();
			}
		}
	}
}
