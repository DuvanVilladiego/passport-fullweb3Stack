const hre = require("hardhat");

async function main() {
  const Passport = await hre.ethers.getContractFactory("Passport");
  const passport = await Passport.deploy();

  await passport.deployed();

  console.log("Passport deployed to:", passport.address);
}

// We recommend this pattern to be able to use async/await everywhere
// and properly handle errors.
main().catch((error) => {
  console.error(error);
  process.exitCode = 1;
});
