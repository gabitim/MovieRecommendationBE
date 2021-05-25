/**************************************************************************
 *                                                                        *
 *  File:        ErrorViewModel.cs                                        *
 *  Copyright:   (c) 2021, Hartan Mihai-Silviu                            *
 *  E-mail:      silviuhartan10@gmail.com                                 *
 *  Description: This model contains the info when an error page needs    *
 *               is shown                                                 *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

namespace MoviesRecommandtions.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
