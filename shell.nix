{ pkgs ? import <nixpkgs> {} }:

pkgs.mkShell {
  nativeBuildInputs = with pkgs; [
    dotnetCorePackages.sdk_8_0_1xx
  ];
}
