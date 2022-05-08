using System;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Lab5_excercise
{
    class App
{
    public static void Main(string[] args)
    {
            Exercise1<string> team = new Exercise1<string>() { Manager = "Adam", MemberA = "Ola", MemberB = "Ewa"};
            foreach(var member in team){
                Console.WriteLine(member);
            }
            CurrencyRates rates = new CurrencyRates();
            rates[Currency.EUR] = 4.6m;
            Console.WriteLine(rates[Currency.EUR]);
            Exercise4 board = new Exercise4();
            board["A5"] = (ChessPiece.King, ChessColor.White);
            Console.WriteLine(board["A5"]);
        }
    }

public class Exercise1<T> : IEnumerable<T>
{
    public T Manager { get; init; }
    public T MemberA { get; init; }
    public T MemberB { get; init; }
    public IEnumerator<T> GetEnumerator()
    {
        yield return Manager;
        yield return MemberA;
        yield return MemberB;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

enum Currency
{
    PLN,
    USD,
    EUR,
    CHF
}

    class CurrencyRates
    {
       
        private decimal[] _rates = new decimal[Enum.GetValues<Currency>().Length];
        
        public decimal this[Currency cur]
        {
            get
            {
                return _rates[(int)cur];
            }
            set
            {
                _rates[(int)cur] = value;
            }
        }
        // Wszystkie waluty
        public override string ToString()
        {
            string result = "";
            foreach (var rate in _rates)
            {
                result += rate + " ";
            }
            return result;
        }
    }

enum ChessPiece
{
    Empty,
    King,
    Queen,
    Rook,
    Bishop,
    Knight,
    Pawn
}

enum ChessColor
{
    Black,
    White
}
    class Exercise4
    {
        private Dictionary<string, (ChessPiece, ChessColor)> _board = new Dictionary<string, (ChessPiece, ChessColor)>();
        public (ChessPiece, ChessColor) this[string coord]
        {
            get
            {
                return _board[coord];
            }
            set
            {
                AddPiece(coord, value.Item1, value.Item2);
            }
        }
        public void AddPiece(string coord, ChessPiece piece, ChessColor color)
        { 
            if (_board.Count >= 32)
            {
                throw new InvalidChessPieceCount();
            }
            if (!IsValidCoord(coord))
            {
                throw new InvalidChessBoardCoordinates();
            }
            if (GetPieceCount(piece, color) >= 2)
            {
                throw new InvalidChessPieceCount();
            }
            _board[coord] = (piece, color);
        }
        public int GetPieceCount(ChessPiece piece, ChessColor color)
        {
            int count = 0;
            foreach (var item in _board)
            {
                if (item.Value.Item1 == piece && item.Value.Item2 == color)
                {
                    count++;
                }
            }
            return count;
        }
        private bool IsValidCoord(string coord)
        {
            if (coord.Length != 2)
            {
                return false;
            }
            if (coord[0] < 'A' || coord[0] > 'H')
            {
                return false;
            }
            if (coord[1] < '1' || coord[1] > '8')
            {
                return false;
            }
            return true;
        }

    }

    class InvalidChessPieceCount : Exception
{

}

class InvalidChessBoardCoordinates : Exception
{

}
}