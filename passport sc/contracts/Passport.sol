// SPDX-License-Identifier: UNLICENSED
pragma solidity ^0.8.9;

import "@openzeppelin/contracts/token/ERC721/extensions/ERC721URIStorage.sol";
import "@openzeppelin/contracts/utils/Counters.sol";
import "@openzeppelin/contracts/access/Ownable.sol";
import "@openzeppelin/contracts/token/ERC1155/ERC1155.sol";
import "@openzeppelin/contracts/token/ERC1155/extensions/ERC1155Supply.sol";

contract Passport is ERC721URIStorage, Ownable  {

    using Counters for Counters.Counter;
    Counters.Counter private _tokenIds;
    
    mapping(uint => address) public minter;
    
    event CreateToken(
        address indexed owner,
        uint256 indexed tokenId
    );

    constructor() ERC721("PassportCertificate", "PC") { }

    function mintPassport(
        address _account, 
        string memory _tokenUri
    ) onlyOwner public returns(uint) 
    {
        address account;
        if (_account == address(0)) {
            account = msg.sender;
        } else {
            account = _account;
        }
        uint256 newItemId = _tokenIds.current();
        _mint(account, newItemId);
        _setTokenURI(newItemId, _tokenUri);
        minter[newItemId]=account;
        _tokenIds.increment();
        return newItemId;
    }
    
    function setURI(uint _newTokenId, string memory _newuri) external onlyOwner {
        _setTokenURI(_newTokenId, _newuri);
    }

}
